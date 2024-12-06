import { useState, useEffect } from "react";
import { useNavigate } from "@remix-run/react";
import { Box, Loader } from '@mantine/core';

enum AppState {
  AUTHENTICATED,
  DENIED,
  LOADING
}

const bypass = true;

export default function ProtectedRoute({ children }: any) {
  const [state, setState] = useState<AppState>(AppState.LOADING);
  const navigate = useNavigate();

  useEffect(() => {
    const checkAuth = () => {
      const token = localStorage.getItem("authToken");

      if (bypass) {
        setState(AppState.AUTHENTICATED);
      } else {
        if (token) {
          const tokenExpiry = JSON.parse(atob(token.split('.')[1])).exp;

          if (tokenExpiry * 1000 < Date.now()) {
            setState(AppState.DENIED);
            return;
          }

          setState(AppState.AUTHENTICATED);
        } else {
          setState(AppState.DENIED);
        }
      }
    };

    checkAuth();

    const intervalId = setInterval(() => {
      checkAuth();
    }, 60 * 1000);

    const handleStorageChange = (e: StorageEvent) => {
      if (e.key === "authToken" && e.newValue !== localStorage.getItem("authToken")) {
        setState(AppState.DENIED);
      }
    };

    window.addEventListener("storage", handleStorageChange);

    return () => {
      clearInterval(intervalId);
      window.removeEventListener("storage", handleStorageChange);
    };
  }, []);

  useEffect(() => {
    if (state === AppState.DENIED) {
      setTimeout(() => {
        navigate("/login", { replace: true });
      }, 0);
    }
  }, [state, navigate]);

  if (state === AppState.LOADING) {
    return (
      <Box style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
        <Loader color="rgba(0, 0, 0, 1)" size="xl" />
      </Box>
    );
  }

  if (state === AppState.DENIED) {
    return null;
  }

  return children;
}

import { Button, Title } from '@mantine/core';
import { useNavigate } from '@remix-run/react';

export default function MainMenu() {
  const navigate = useNavigate();

  return (
    <div className="min-h-screen flex justify-center items-center bg-white px-6 relative">
      <div className="w-full max-w-sm space-y-8 text-center">
        <img
          src="/icon-192x192.png"
          alt="App Icon"
          className="mx-auto mb-6"
          width="96"
          height="96"
        />
        <Title order={2} className="text-gray-800" style={{ fontWeight: 600, fontSize: '2rem' }}>
          Welcome to MovieList
        </Title>
        <div className="space-y-4">
          <Button fullWidth onClick={() => navigate("/listoverview")}>View My Lists</Button>
          <Button fullWidth onClick={() => navigate("/search")}>Search Movies</Button>
          <Button
            fullWidth
            color="red"
            onClick={() => {
              localStorage.removeItem("authToken");
              navigate("/login");
            }}
          >
            Logout
          </Button>
        </div>
      </div>
    </div>
  );
}

import type { MetaFunction } from "@remix-run/node";
import MainMenu from "./mainmenu";
import ProtectedRoute from "~/components/layouts/ProtectedRoute";

export const meta: MetaFunction = () => {
  return [
    { title: "MovieList" },
    { name: "description", content: "Welcome to MovieList!" },
  ];
};

export default function Index() {
  return (
    <ProtectedRoute>
      <MainMenu></MainMenu>
    </ProtectedRoute>
  );
}


import { MantineProvider } from '@mantine/core';
import { Links, Meta, Outlet, Scripts, ScrollRestoration } from "@remix-run/react";

import '@mantine/core/styles.css';
import './tailwind.css';

export default function App() {
  return (
    <html lang="en">
      <head>
        <meta charSet="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1" />
        <link rel="manifest" href="/manifest.json" />
        <meta name="apple-mobile-web-app-title" content="MovieList" />
        <meta name="mobile-web-app-capable" content="yes" />
        <meta name="apple-mobile-web-app-status-bar-style" content="default" />
        <link rel="apple-touch-icon" href="/icon-192x192.png" />
        <Meta />
        <Links />
      </head>
      <body>
        <MantineProvider>
          <Outlet />
        </MantineProvider>
        <ScrollRestoration />
        <Scripts />
      </body>
    </html>
  );
}

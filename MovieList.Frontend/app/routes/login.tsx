import { Button, TextInput, Title } from '@mantine/core';
import { useNavigate } from '@remix-run/react';
import { useState } from 'react';

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate();

  const handleLogin = (e: React.FormEvent) => {
    e.preventDefault();

    
    // Simulate login logic here (you can replace this with your actual login logic)


    navigate("/mainmenu"); 
  };

  return (
    <div className="min-h-screen flex justify-center items-center bg-white px-6">
      <div className="w-full max-w-sm space-y-8 text-center">
        <img 
          src="/icon-192x192.png" 
          alt="App Icon" 
          className="mx-auto mb-6" 
          width="96" 
          height="96" 
        />

        <Title order={2} className="text-gray-800" style={{ fontWeight: 600, fontSize: '2rem' }}>
          Welcome Back!
        </Title>

        <form onSubmit={handleLogin} className="space-y-4">
          <TextInput
            label="Email"
            placeholder="Enter your email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            className="mb-4"
            radius="md"
            size="lg"
            style={{
              backgroundColor: '#f8f8f8', 
              border: 'none',
              padding: '0.75rem',
              boxShadow: 'none', 
              fontSize: '16px',
            }}
          />

          <TextInput
            label="Password"
            type="password"
            placeholder="Enter your password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="mb-6"
            radius="md"
            size="lg"
            style={{
              backgroundColor: '#f8f8f8', 
              border: 'none', 
              padding: '0.75rem',
              boxShadow: 'none',
              fontSize: '16px', 
            }}
          />

          <Button
            fullWidth
            type="submit"
            color="blue"
            radius="md"
            size="lg"
            style={{
              fontWeight: 600,
              backgroundColor: '#007bff',
              padding: '1rem',
              textTransform: 'uppercase',
            }}
          >
            Login
          </Button>
        </form>

        <p className="text-sm text-gray-600">
          Don't have an account?{' '}
          <a href="/register" className="text-blue-500 hover:underline">Register here</a>
        </p>
      </div>
    </div>
  );
}

import { Button, TextInput, Title } from '@mantine/core';
import { useState } from 'react';
import { useNavigate } from '@remix-run/react';

export default function Register() {
  const [email, setEmail] = useState('');
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleRegister = (e: React.FormEvent) => {
    e.preventDefault();

    if (password !== confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    localStorage.setItem("authToken", "sampleAuthToken"); 
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
          Create an Account
        </Title>
        <form onSubmit={handleRegister} className="space-y-4">
          <TextInput
            label="Email"
            placeholder="Enter your email"
            type="email"
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
            label="Username"
            placeholder="Enter your username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
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
            label="Confirm Password"
            type="password"
            placeholder="Confirm your password"
            value={confirmPassword}
            onChange={(e) => setConfirmPassword(e.target.value)}
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
          
          {error && <div className="text-red-500 text-sm mb-4">{error}</div>}
          
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
            Register
          </Button>
        </form>
        
        <p className="text-sm text-gray-600">
          Already have an account?{' '}
          <a href="/login" className="text-blue-500 hover:underline">Login here</a>
        </p>
      </div>
    </div>
  );
}

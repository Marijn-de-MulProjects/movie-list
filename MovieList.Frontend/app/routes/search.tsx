import { Button, TextInput, Title } from '@mantine/core';
import { useState } from 'react';
import BackButton from '~/components/BackButton';

export default function Search() {
  const [query, setQuery] = useState('');

  const handleSearch = () => {
    console.log('Searching for:', query);
    
    // Add search logic here

  };

  return (
    <div className="min-h-screen flex justify-center items-center bg-white px-6">
      <BackButton></BackButton>
      <div className="w-full max-w-sm space-y-8 text-center">
        <img
          src="/icon-192x192.png"
          alt="App Icon"
          className="mx-auto mb-6"
          width="96"
          height="96"
        />
        <Title order={2} className="text-gray-800" style={{ fontWeight: 600, fontSize: '2rem' }}>
          Search Movies
        </Title>
        <div className="space-y-4">
          <TextInput
            label="Search"
            placeholder="Enter movie name"
            value={query}
            onChange={(e) => setQuery(e.target.value)}
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
          <Button fullWidth onClick={handleSearch}>Search</Button>
        </div>
      </div>
    </div>
  );
}

import { Button, Title, Text } from '@mantine/core';
import BackButton from '~/components/BackButton';

export default function ListDetails() {
  return (
    <div className="min-h-screen flex justify-center items-center bg-white px-6">
      <BackButton /> 
      <div className="w-full max-w-sm space-y-8 text-center">
        <img
          src="/icon-192x192.png"
          alt="App Icon"
          className="mx-auto mb-6"
          width="96"
          height="96"
        />
        <Title order={2} className="text-gray-800" style={{ fontWeight: 600, fontSize: '2rem' }}>
          List Details
        </Title>

        <Text className="text-lg font-medium">My Movie List</Text>

        <Text className="text-sm text-gray-600 mt-2">This is a list of my favorite movies to watch with friends!</Text>

        <div className="mt-6">
          <Title order={3} className="text-gray-800" style={{ fontWeight: 600, fontSize: '1.5rem' }}>
            Shared with:
          </Title>
          <Text className="text-sm text-gray-600 mt-2">John Doe, Jane Smith</Text>
        </div>

        <div className="mt-6">
          <Title order={3} className="text-gray-800" style={{ fontWeight: 600, fontSize: '1.5rem' }}>
            Movies in this List:
          </Title>
          <ul className="text-sm text-gray-600 mt-2 space-y-2">
            <li>Movie 1</li>
            <li>Movie 2</li>
            <li>Movie 3</li>
          </ul>
        </div>

        <div className="mt-8 space-y-4">
          <Button fullWidth>View Movie Details</Button>
          <Button fullWidth color="red">Delete List</Button>
        </div>
      </div>
    </div>
  );
}

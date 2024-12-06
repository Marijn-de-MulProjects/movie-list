import { Button, Title } from '@mantine/core';
import BackButton from '~/components/BackButton';

export default function MovieOverview() {
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
          Movie Overview
        </Title>
        <Button fullWidth>Back to Search</Button>
      </div>
    </div>
  );
}

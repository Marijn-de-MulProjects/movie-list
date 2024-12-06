import { Button, Title } from '@mantine/core';
import { useNavigate } from '@remix-run/react';
import BackButton from '~/components/BackButton';

export default function ListOverview() {
  const navigate = useNavigate();

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
          My Movie Lists
        </Title>
        <div className="space-y-4">
          <Button fullWidth onClick={() => navigate('/list-details/1')}>View List 1</Button>
          <Button fullWidth onClick={() => navigate('/list-details/2')}>View List 2</Button>
        </div>
      </div>
    </div>
  );
}

import { useNavigate } from '@remix-run/react';
import { Button } from '@mantine/core';

export default function BackButton() {
  const navigate = useNavigate();

  return (
    <Button
      variant="link"
      onClick={() => navigate(-1)}
      style={{
        position: 'absolute',
        top: '20px',
        left: '20px',
        padding: '8px',
        fontSize: '18px',
        textDecoration: 'none',
      }}
    >
      &#x2190; Back
    </Button>
  );
}

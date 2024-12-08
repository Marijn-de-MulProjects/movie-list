import { Button, TextInput, Title } from '@mantine/core';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom'; // Assuming you're using react-router
import BackButton from '~/components/BackButton';

export default function Search() {
  const [query, setQuery] = useState('');
  const [movies, setMovies] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [searched, setSearched] = useState(false); // To track if a search has been performed
  const navigate = useNavigate();

  const handleSearch = async () => {
    if (!query) return; // Avoid empty search

    setLoading(true);
    setError('');
    setSearched(true); // Set searched to true after searching

    try {
      const authToken = localStorage.getItem('authToken'); // Retrieve the authToken from localStorage
      const url = `https://backend:7087/api/movies/search?movieName=${encodeURIComponent(query)}`;
      
      const response = await fetch(url, {
        method: 'GET',
        headers: {
          'Authorization': authToken ? `Bearer ${authToken}` : '', // Attach the authToken if present
          'Accept': 'application/json'
        }
      });

      if (!response.ok) {
        throw new Error('Failed to fetch movies');
      }

      const data = await response.json();
      setMovies(data); // Set the fetched movies to the state
    } catch (error) {
      console.error('Error:', error);
      setError('Error fetching movie data');
    } finally {
      setLoading(false); // Reset loading state
    }
  };

  const handleMovieClick = (movieId) => {
    // Navigate to the movie overview page with the selected movie ID
    navigate(`/movie/${movieId}`);
  };

  return (
    <div className="min-h-screen bg-white px-6 relative">
      {/* BackButton and layout */}
      <BackButton />
      
      <div className="w-full max-w-sm space-y-8 text-center">
        {/* Show the logo and search bar before searching */}
        {!searched && (
          <div className="flex flex-col items-center mb-8 mt-16"> {/* Adjusted top margin */}
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
          </div>
        )}

        {/* Search bar */}
        <div className={`space-y-4 ${searched ? 'mt-8' : ''}`}>
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
          <Button fullWidth onClick={handleSearch} loading={loading}>Search</Button>
        </div>
      </div>

      {/* Display error message if there was an issue with the search */}
      {error && <div className="text-red-500 mt-4">{error}</div>}

      {/* Display search results */}
      {movies.length > 0 && (
        <div className="mt-6 grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-2 gap-4">
          {movies.map((movie) => (
            <div
              key={movie.id}
              className="bg-white shadow-lg rounded-lg overflow-hidden cursor-pointer"
              onClick={() => handleMovieClick(movie.id)}
            >
              <img
                src={movie.pictureUrl || "https://via.placeholder.com/500x750.png?text=No+Image"}
                alt={movie.name}
                className="w-full h-48 object-cover"
              />
              <div className="p-3">
                <h3 className="font-semibold text-lg">{movie.name}</h3>
              </div>
            </div>
          ))}
        </div>
      )}
    </div>
  );
}

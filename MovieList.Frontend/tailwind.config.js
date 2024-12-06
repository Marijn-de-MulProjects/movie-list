/** @type {import('tailwindcss').Config} */
export default {
  content: [
    "./app/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#007AFF",  
        secondary: "#F7F7F7", 
        gray: {
          100: "#F2F2F7",  
          900: "#1C1C1E",  
        },
      },
      fontFamily: {
        sans: ["-apple-system, BlinkMacSystemFont", "Segoe UI", "Roboto", "Oxygen", "Ubuntu", "Cantarell", "Fira Sans", "Droid Sans"],
      },
      boxShadow: {
        DEFAULT: "0 1px 2px rgba(0, 0, 0, 0.05)",  
      },
      borderRadius: {
        'xl': '20px', 
      },
    },
  },
  plugins: [],
}


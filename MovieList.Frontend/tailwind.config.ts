// tailwind.config.js
module.exports = {
  content: [
    "./app/**/*.{js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: "#007AFF",  // iOS blue
        secondary: "#F7F7F7", // light background
        gray: {
          100: "#F2F2F7",  // soft gray for backgrounds
          900: "#1C1C1E",  // dark text
        },
      },
      fontFamily: {
        sans: ['"San Francisco"', 'Arial', 'sans-serif'],
      },
      boxShadow: {
        DEFAULT: "0 1px 2px rgba(0, 0, 0, 0.1)",  // subtle shadow
      },
      borderRadius: {
        'xl': '20px', // larger rounded corners for iOS look
      },
    },
  },
  plugins: [],
};

// src/App.js
import React, { useState } from 'react';
import BookDetails from './BookDetails';
import BlogDetails from './BlogDetails';
import CourseDetails from './CourseDetails';
import './App.css';

function App() {
  const [showBook, setShowBook] = useState(true);
  const [showBlog, setShowBlog] = useState(true);
  const [showCourse, setShowCourse] = useState(true);

  return (
    <div className="App">
      <h1>Blogger App</h1>

      {/* Toggle Buttons */}
      <div className="buttons">
        <button onClick={() => setShowBook(!showBook)}>
          {showBook ? 'Hide' : 'Show'} Book
        </button>
        <button onClick={() => setShowBlog(!showBlog)}>
          {showBlog ? 'Hide' : 'Show'} Blog
        </button>
        <button onClick={() => setShowCourse(!showCourse)}>
          {showCourse ? 'Hide' : 'Show'} Course
        </button>
      </div>

      {/* Columns */}
      <div className="columns">
        {showBook && (
          <div className="column">
            <BookDetails />
          </div>
        )}

        {showBlog && (
          <div className="column">
            <BlogDetails />
          </div>
        )}

        {showCourse && (
          <div className="column">
            <CourseDetails />
          </div>
        )}
      </div>
    </div>
  );
}

export default App;

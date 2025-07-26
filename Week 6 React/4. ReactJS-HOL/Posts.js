import React from 'react';
import Post from './Posts';

class Posts extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      hasError: false
    };
  }

  // Step 6: Fetch posts
  loadPosts() {
    fetch('https://jsonplaceholder.typicode.com/posts')
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not OK');
        }
        return response.json();
      })
      .then(data => {
        this.setState({ posts: data });
      })
      .catch(error => {
        console.error('Error fetching posts:', error);
        this.setState({ hasError: true });
      });
  }

  // Step 7: Load data after component mounts
  componentDidMount() {
    this.loadPosts();
  }

  // Step 9: Handle errors gracefully
  componentDidCatch(error, info) {
    alert('An error occurred: ' + error.message);
  }

  // Step 8: Render the posts
  render() {
    return (
      <div>
        <h2>Blog Posts</h2>
        {this.state.posts.length === 0 && <p>Loading posts...</p>}
        {this.state.posts.map(post => (
          <Post key={post.id} title={post.title} body={post.body} />
        ))}
      </div>
    );
  }
}

export default Posts;


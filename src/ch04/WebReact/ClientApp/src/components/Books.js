import React, { Component } from 'react';

export class Books extends Component {
    static displayName = Books.name;

  constructor(props) {
    super(props);
    this.state = { books: [], loading: true };
  }

  componentDidMount() {
    this.booksData();
  }

  static renderTable(books) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>id</th>
            <th>title</th>
            <th>author</th>
            <th>publish</th>
          </tr>
        </thead>
        <tbody>
          {books.map(item =>
            <tr key={item.id}>
                  <td>{item.id}</td>
                  <td>{item.title}</td>
                  <td>{item.author}</td>
                  <td>{item.publisher}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
        : Books.renderTable(this.state.books);

    return (
      <div>
        <h1 id="tabelLabel" >書籍一覧</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

    async booksData() {
    const response = await fetch('api/books');
    const data = await response.json();
    this.setState({ books: data, loading: false });
  }
}

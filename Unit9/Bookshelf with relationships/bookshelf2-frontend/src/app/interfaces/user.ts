export interface User {
    // The id is marked as optional (?) because as we are creating new books, they
    // will not have an ID until the database assigns one.
    id?: number;
    username: string;
    displayName: string;
  }
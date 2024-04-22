import { User } from "./user";


export default interface Book {
  // The id is marked as optional (?) because as we are creating new books, they
  // will not have an ID until the database assigns one.
  id?: number;
  title: string;
  author: string;
  pages: number;
  lentOut: boolean;
  // simply the ID of the related user
  ownerId: number;
	// nested user object
  lentOutTo: User|null;
}
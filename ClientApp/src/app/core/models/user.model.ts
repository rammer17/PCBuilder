export type UserSignUpRequest = {
  fullName: string;
  email: string;
  password: string;
};

export type UserSignInRequest = {
  email: string;
  password: string;
};

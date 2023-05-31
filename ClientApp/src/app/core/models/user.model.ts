export type UserGetInfoResponse = {
  fullName: string;
  email: string;
  description: string;
  imageUrl: string
  role: string;
};
export type UserSignUpRequest = {
  fullName: string;
  email: string;
  description: string;
  password: string;
};

export type UserSignInRequest = {
  email: string;
  password: string;
};

export type UserChangeAvatarRequest = {
  imageUrl: string;
};

export type UserChangeDescriptionRequest = {
  newDescription: string;
};

export type UserChangePasswordRequest = {
  newPassword: string;
};

export type Account = {
  fullName?: string;
  email?: string;
  description?: string;
  imageUrl?: string;
  role?: string;
};

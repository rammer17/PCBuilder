export type UserGetInfoResponse = {
  fullName: string;
  email: string;
  description: string;
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
  newAvatar: string;
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
  role?: string;
};

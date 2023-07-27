export interface User {
    username: string;
    photoUrl: string;
    knownAs: string;
    gender: string;
    roles: string[];
}

export interface RegistrationRequest {
    userName: string;
    password: string;
    gender: string;
    dateOfBirth: string;
    city: string;
    country: string;
}

export interface LoginRequest {
    userName: string;
    password: string;
}

export interface LoginResponse {
    token: string;
    user: User;
}
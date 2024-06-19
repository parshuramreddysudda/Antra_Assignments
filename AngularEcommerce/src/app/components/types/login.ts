export interface LoginResponse {
    id: number;
    fullName: string;
    email: string;
    gender:string;
    phone:string;
    profilePic:string;
    role: string;
    userId: string;
    token: string;
    claims: Claim[];
  }
  
  export interface Claim {
    claimType: string;
    claimValue: string;
  }
  
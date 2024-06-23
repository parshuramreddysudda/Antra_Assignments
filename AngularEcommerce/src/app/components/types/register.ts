export interface Register{
   id: number,
  fullName: string,
  email: string,
  role: string,
  userId: string,
  token: string,
  gender: string,
  phone: string,
  profilePic: string,
  claims: [
    {
      claimType: string,
      claimValue: string
    }
  ]
}
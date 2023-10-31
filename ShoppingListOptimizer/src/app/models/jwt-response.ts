export interface JwtResponse {
  token:{
    accessToken:string,
    refreshToken:{
      username:string,
      tokenString:string,
      expireAt:string
    }
  }
}

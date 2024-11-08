export type User = {
    "id": number,
    "login": string,
    

}
export type UserResponse = {
    "success": boolean,
    "result": User[],
    "total":Number
}

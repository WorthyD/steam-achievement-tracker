// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

export class User {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: string, userName?: string, roles?: string[]) {

    this.id = id;
    this.userName = userName;
    this.roles = roles;
  }



  public id: string;
  public userName: string;
  public roles: string[];
  public isEnabled: boolean;
}

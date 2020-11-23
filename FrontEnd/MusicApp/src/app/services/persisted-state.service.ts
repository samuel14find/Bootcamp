import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PersistedStateService {

  constructor() { }

  public LOGGED_IN: string = "AUTHENTICATED_USER";

  public set (key: string, data: any){
    localStorage.setItem(key, JSON.stringify(data));
  }

  public get(key: string){
    return JSON.parse(localStorage.getItem(key));
  }

  public remove(key: string){
    localStorage.removeItem(key);
  }

  // !! dentro do JS significa se quero ver a variável, se o objeto é nulo. Ele também verifica se o 
  // tipo do objeto está nulo.
  public exists(key: string){
    return !!localStorage.getItem(key);
  }
}

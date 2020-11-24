import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Album from 'app/model/album';
import User from 'app/model/user';
import { MusicService } from 'app/services/music.service';
import { PersistedStateService } from 'app/services/persisted-state.service';
import { UserService } from 'app/services/user.service';

@Component({
  selector: 'app-music-detail',
  templateUrl: './music-detail.component.html',
  styleUrls: ['./music-detail.component.scss']
})
export class MusicDetailComponent implements OnInit {
  albumId: String = undefined;
  album: Album = undefined;
  user: User;

  // Com a classe ActivateRoute vamos conseguir buscar a informação que necessitamos. Nesse caso o identi
  //ficador da rota. Nesse caso qual Album queremos exibir.
  // O router é o responsável por navegar entre os componentes. Se estou querendo voltar uma página 
  // na verdade estou querendo chamar um componente 
  constructor(private musicService: MusicService,
              private activeRoute: ActivatedRoute,
              private router: Router,
              private persistedState: PersistedStateService,
              private userService: UserService) 
              { }

  ngOnInit() {
    this.albumId = this.activeRoute.snapshot.paramMap.get("id");// Esse id é o mesmo que definimos lá no music-routing.module
    this.musicService.getAlbumDetail(this.albumId).subscribe(data=>{
      this.album = data;
    })

    this.user = this.persistedState.get(this.persistedState.LOGGED_IN);
  }


  back(){
    this.router.navigate(["music"]);
  }

  isFavoritMusic(musicId){
    return this.user.favoritMusics.findIndex(x=> x.musicId == musicId) >= 0;
  }

  toogleFavorite(musicId){
    if(this.isFavoritMusic(musicId) === false){
      this.addToFavorite(musicId)
    } else {
      this.removeFromFavorite(musicId);
    }
  }
  private addToFavorite(musicId: any) {
    this.userService.addToFavorite(this.user.id, musicId).subscribe((data)=>{
      this.userService.getUser(this.user.id).subscribe(data=>{
        this.user = data;
        this.persistedState.set(this.persistedState.LOGGED_IN, this.user);
      })
    });
  }
  private removeFromFavorite(musicId: any) {
    this.userService.removeFromFavorite(this.user.id, musicId).subscribe(data =>{
           // Primeiro eu removo a música que acabou se removida do banco de dados. Porque eu preciso 
            // retirar ela do grid. Sendo assim eu faço um filtro onde o Id é diferente do id que tá favoritado
            this.user.favoritMusics = this.user.favoritMusics.filter( (x) => x.musicId != musicId);
            // Aqui atualizamos a persistência de dados. A partir do momento que já removi, eu tenho que 
            // atualizar para manter a consistência de informações. 
            this.persistedState.set(this.persistedState.LOGGED_IN, this.user);
    });
  }

}

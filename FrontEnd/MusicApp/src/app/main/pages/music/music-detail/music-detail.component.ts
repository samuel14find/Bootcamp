import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Album from 'app/model/album';
import { MusicService } from 'app/services/music.service';

@Component({
  selector: 'app-music-detail',
  templateUrl: './music-detail.component.html',
  styleUrls: ['./music-detail.component.scss']
})
export class MusicDetailComponent implements OnInit {
  albumId: String = undefined;
  album: Album = undefined;

  // Com a classe ActivateRoute vamos conseguir buscar a informação que necessitamos. Nesse caso o identi
  //ficador da rota. Nesse caso qual Album queremos exibir.
  // O router é o responsável por navegar entre os componentes. Se estou querendo voltar uma página 
  // na verdade estou querendo chamar um componente 
  constructor(private musicService: MusicService,
              private activeRoute: ActivatedRoute,
              private router: Router) 
              { }

  ngOnInit() {
    this.albumId = this.activeRoute.snapshot.paramMap.get("id");// Esse id é o mesmo que definimos lá no music-routing.module
    this.musicService.getAlbumDetail(this.albumId).subscribe(data=>{
      this.album = data;
    })
  }

  back(){
    this.router.navigate(["music"]);
  }

}

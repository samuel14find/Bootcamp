import { Component, OnInit } from '@angular/core';
import Album from 'app/model/album';
import { MusicService } from 'app/services/music.service';

@Component({
  selector: 'app-music',
  templateUrl: './music.component.html',
  styleUrls: ['./music.component.scss']
})
export class MusicComponent implements OnInit {
  albuns: Album[] = []

  constructor(private musicService: MusicService) { }

  ngOnInit() {
    this.musicService.getAlbuns().subscribe(result=>{
      this.albuns = result;
      console.log(this.albuns);
    })
  }

}

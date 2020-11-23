import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import User from 'app/model/user';
import { PersistedStateService } from 'app/services/persisted-state.service';
import { UserService } from 'app/services/user.service';
import Swal from "sweetalert2";

@Component({
    selector: "app-favorite",
    templateUrl: "./favorite.component.html",
    styleUrls: ["./favorite.component.scss"],
})
export class FavoriteComponent implements OnInit {
    user: User;
    displayedColumns: string[] = [
        "position",
        "name",
        "band",
        "avatar",
        "album",
        "action",
    ];
    dataSource: any[];

    constructor(private persistedState: PersistedStateService, 
               private router: Router, private userService: UserService) {}

    ngOnInit() {
        this.user = this.persistedState.get(this.persistedState.LOGGED_IN);
        this.dataSource = this.user.favoritMusics as any;
    }
    goToDetail(albumId){
        this.router.navigate(["music", albumId]);
    }

    removeFromFavorite(musicId){

        this.userService.removeFromFavorite(this.user.id, musicId).subscribe(()=>{
            // Primeiro eu removo a música que acabou se removida do banco de dados. Porque eu preciso 
            // retirar ela do grid. Sendo assim eu faço um filtro onde o Id é diferente do id que tá favoritado
            this.user.favoritMusics = this.user.favoritMusics.filter(x=>x.musicId != musicId);
            // Aqui atualizamos a persistência de dados. A partir do momento que já removi, eu tenho que 
            // atualizar para manter a consistência de informações. 
            this.persistedState.set(this.persistedState.LOGGED_IN, this.user);
            //Aqui eu atualizo a visualização do usuário. Para que quando ele olhar a tabela e ter a sensação 
            //que a linha foi removida. 
            this.dataSource = this.user.favoritMusics as any;
            Swal.fire(
                "Sucesso!",
                "Musica Removida dos favoritos",
                "success"
            )
        });  
    }
}

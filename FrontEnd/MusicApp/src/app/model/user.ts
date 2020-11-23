import FavoriteMusic from './favoriteMusic';

export default class User{
    public id?: string;
    public name?: string;
    public photo?: string;
    public favoritMusics: FavoriteMusic[];
}
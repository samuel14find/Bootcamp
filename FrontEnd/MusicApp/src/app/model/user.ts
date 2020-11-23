import FavoriteMusic from './favoriteMusic';

export default class User{
    public id?: String;
    public name?: String;
    public photo?: String;
    public favoriteMusics: FavoriteMusic[];
}
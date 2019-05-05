import { Component, OnInit } from '@angular/core';
import { Article } from '../models/article.model';
import { ArticleService } from './articlesService';

@Component({
	selector: 'app-articles',
	templateUrl: './articles.component.html',
	styleUrls: [ './articles.component.css' ]
})
export class ArticlesComponent implements OnInit {
	articles: Article[];
	constructor(private articlesService: ArticleService) {}

	ngOnInit() {
		this.articles = this.articlesService.getData();
	}
}

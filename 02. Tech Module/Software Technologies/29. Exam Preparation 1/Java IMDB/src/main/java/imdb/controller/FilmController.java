package imdb.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import imdb.bindingModel.FilmBindingModel;
import imdb.entity.Film;
import imdb.repository.FilmRepository;

import java.util.List;

@Controller
public class FilmController {

	private final FilmRepository filmRepository;

	@Autowired
	public FilmController(FilmRepository filmRepository) {
		this.filmRepository = filmRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Film> films = filmRepository.findAll();
		model.addAttribute("films", films);
		model.addAttribute("view", "film/index");
		return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("film", new FilmBindingModel());
		model.addAttribute("view", "film/create");
		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, FilmBindingModel filmBindingModel) {
		if(filmBindingModel.getName().equals("") ||
				filmBindingModel.getGenre().equals("") ||
				filmBindingModel.getDirector().equals("") ||
				filmBindingModel.getYear() == null){
			model.addAttribute("film", filmBindingModel);
			model.addAttribute("view", "film/create");
			return "base-layout";
		}

		Film film = new Film();
		film.setName(filmBindingModel.getName());
		film.setGenre(filmBindingModel.getGenre());
		film.setDirector(filmBindingModel.getDirector());
		film.setYear(filmBindingModel.getYear());

		filmRepository.saveAndFlush(film);

		return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
		Film film = filmRepository.findOne(id);
		if(film != null) {
			model.addAttribute("film", film);
			model.addAttribute("view", "film/edit");
			return "base-layout";
		}
		return "redirect:/";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model, @PathVariable int id, FilmBindingModel filmBindingModel) {
		if(filmBindingModel.getName().equals("") ||
				filmBindingModel.getGenre().equals("") ||
				filmBindingModel.getDirector().equals("") ||
				filmBindingModel.getYear() == null){
			Film film = new Film();
			film.setId(id);
			film.setName(filmBindingModel.getName());
			film.setGenre(filmBindingModel.getGenre());
			film.setDirector(filmBindingModel.getDirector());
			film.setYear(filmBindingModel.getYear());
			model.addAttribute("film", film);
			model.addAttribute("view", "film/edit");
			return "base-layout";
		}


		Film film = filmRepository.findOne(id);
		if(film != null){
			film.setName(filmBindingModel.getName());
			film.setGenre(filmBindingModel.getGenre());
			film.setDirector(filmBindingModel.getDirector());
			film.setYear(filmBindingModel.getYear());

			filmRepository.saveAndFlush(film);
		}

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		Film film = filmRepository.findOne(id);
		if(film != null) {
			model.addAttribute("film", film);
			model.addAttribute("view", "film/delete");
			return "base-layout";
		}
		return "redirect:/";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id) {

		Film film = filmRepository.findOne(id);
		if(film != null){
			filmRepository.delete(id);
		}

		return "redirect:/";
	}
}

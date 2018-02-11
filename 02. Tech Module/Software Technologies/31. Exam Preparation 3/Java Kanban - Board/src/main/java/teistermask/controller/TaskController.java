package teistermask.controller;


import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

import java.util.List;
import java.util.stream.Collectors;

import static org.codehaus.groovy.runtime.DefaultGroovyMethods.collect;

@Controller
public class TaskController {
	private final TaskRepository taskRepository;

	@Autowired
	public TaskController(TaskRepository taskRepository) {
		this.taskRepository = taskRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Task> tasks = this.taskRepository.findAll();

		List<Task> openTasks = tasks.stream().filter(task -> {
            if (task.getStatus().equals("Open"))
                return  true;
            return false;
        }).collect(Collectors.toList());

        List<Task> inProgressTasks = tasks.stream().filter(task -> {
            if (task.getStatus().equals("In Progress"))
                return  true;
            return false;
        }).collect(Collectors.toList());

        List<Task> finishedTasks = tasks.stream().filter(task -> {
            if (task.getStatus().equals("Finished"))
                return  true;
            return false;
        }).collect(Collectors.toList());

        model.addAttribute("openTasks", openTasks);
        model.addAttribute("inProgressTasks", inProgressTasks);
		model.addAttribute("finishedTasks", finishedTasks);
		model.addAttribute("view","task/index");
        return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
        model.addAttribute("task", new TaskBindingModel());
        model.addAttribute("view", "task/create");
        return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, TaskBindingModel taskBindingModel, BindingResult bindingResult) {
        if (bindingResult.hasErrors()) {
            model.addAttribute("message", "Invalid data.");
            model.addAttribute("task", taskBindingModel);
            model.addAttribute("view", "task/create");
            return "base-layout";
        }

        Task task = new Task();
        task.setTitle(taskBindingModel.getTitle());
        task.setStatus(taskBindingModel.getStatus());

        taskRepository.saveAndFlush(task);

        return "redirect:/";
	}

	@GetMapping("/edit/{id}")
	public String edit(Model model, @PathVariable int id) {
        Task task = this.taskRepository.findOne(id);
        if (task == null)
            return "redirect:/";

        model.addAttribute("task", task);
        model.addAttribute("view", "task/edit");
        return "base-layout";
	}

	@PostMapping("/edit/{id}")
	public String editProcess(Model model,@PathVariable int id, TaskBindingModel taskBindingModel, BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            model.addAttribute("message", "Invalid data.");
            model.addAttribute("task", taskBindingModel);
            model.addAttribute("view", "task/edit");
            return "base-layout";
        }

        Task task = this.taskRepository.findOne(id);
        if(task == null){
            return "redirect:/";
        }

        task.setTitle(taskBindingModel.getTitle());
        task.setStatus(taskBindingModel.getStatus());

        taskRepository.saveAndFlush(task);

        return "redirect:/";
	}
}

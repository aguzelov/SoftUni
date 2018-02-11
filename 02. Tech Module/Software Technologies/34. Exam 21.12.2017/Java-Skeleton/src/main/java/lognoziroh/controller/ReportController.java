package lognoziroh.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import lognoziroh.bindingModel.ReportBindingModel;
import lognoziroh.repository.ReportRepository;
import lognoziroh.entity.Report;

import java.util.List;

@Controller
public class ReportController {
	private final ReportRepository reportRepository;

	@Autowired
	public ReportController(ReportRepository reportRepository) {
		this.reportRepository = reportRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Report> reports =  this.reportRepository.findAll();
		model.addAttribute("reports", reports);
		model.addAttribute("view", "report/index");
		return "base-layout";
	}

	@GetMapping("/details/{id}")
	public String details(Model model, @PathVariable int id) {
        Report report = this.reportRepository.findOne(id);
        if (report == null)
            return "redirect:/";

        model.addAttribute("report", report);
        model.addAttribute("view", "report/details");
        return "base-layout";
	}

	@GetMapping("/create")
	public String create(Model model) {
        model.addAttribute("report", new ReportBindingModel());
        model.addAttribute("view", "report/create");
        return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, ReportBindingModel reportBindingModel, BindingResult bindingResult) {

        if (bindingResult.hasErrors()) {
            model.addAttribute("message", "Invalid data.");
            model.addAttribute("report", reportBindingModel);
            model.addAttribute("view", "report/create");
            return "base-layout";
        }

        Report report = new Report();
        report.setStatus(reportBindingModel.getStatus());
        report.setMessage(reportBindingModel.getMessage());
        report.setOrigin(reportBindingModel.getOrigin());
        reportRepository.saveAndFlush(report);

        return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
        Report report = this.reportRepository.findOne(id);
        if (report == null)
            return "redirect:/";

        model.addAttribute("report", report);
        model.addAttribute("view", "report/delete");
        return "base-layout";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id, ReportBindingModel reportBindingModel) {
        Report report = this.reportRepository.findOne(id);
        if (report == null)
            return "redirect:/";

        reportRepository.delete(report);
        reportRepository.flush();

        return "redirect:/";
	}
}

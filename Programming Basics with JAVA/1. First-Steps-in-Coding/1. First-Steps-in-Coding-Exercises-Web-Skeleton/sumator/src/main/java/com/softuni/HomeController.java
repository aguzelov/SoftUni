package com.softuni;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
	@GetMapping("/")
	public String index() {
		return "index";
	}
	
	@PostMapping("/")
	public String sum(@RequestParam String num1, @RequestParam String num2, Model model) {
		model.addAttribute("num1", num1);
		model.addAttribute("num2", num2);
		double result = Double.parseDouble(num1) + Double.parseDouble(num2);
		model.addAttribute("result", result);
		return "index";
	}
}

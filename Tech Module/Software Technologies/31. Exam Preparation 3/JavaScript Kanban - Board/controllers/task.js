

const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
        let openTasks = new Array();
        let inProgressTasks = new Array();
        let finishedTasks = new Array();

        Task.find().then(task =>{
            for(let i = 0; i < task.length; i++){
                if(task[i].status === "Open"){
                    openTasks.push(task[i]);
                }else if(task[i].status === "In Progress"){
                    inProgressTasks.push(task[i]);
                }else if(task[i].status === "Finished"){
                    finishedTasks.push(task[i]);
                }
            }
            return res.render('task/index', {
                'openTasks': openTasks,
                'inProgressTasks': inProgressTasks,
                'finishedTasks': finishedTasks
            })

        }).catch(err => {
            return res.send("error");
        });

	},
	createGet: (req, res) => {
        res.render('task/create');
		return null;
	},
	createPost: (req, res) => {
		let task = req.body;
		Task.create(task).then(task => {
		    res.redirect("/");
        }).catch(err => {
            task.error = "Cannot create task.";
            res.render('task/create', task);
        });
	},
	editGet: (req, res) => {
        let taskId = req.params.id;
        Task.findById(taskId).then(task => {
            if (task) {
                res.render('task/edit', task );
            }
            else {
                res.redirect('/');
            }
        }).catch(err => res.redirect('/'));
	},
	editPost: (req, res) => {
        let taskId = req.params.id;
        let task = req.body;

        Task.findByIdAndUpdate(taskId, task, {runValidators: true}).then(task => {
            res.redirect("/");
        }).catch(err => {
            task.id = taskId;
            task.error = "Cannot edit task.";
            return res.render("task/edit", task);
        });
	}
};
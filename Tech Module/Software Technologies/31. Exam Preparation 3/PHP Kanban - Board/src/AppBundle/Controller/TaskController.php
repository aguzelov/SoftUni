<?php

namespace AppBundle\Controller;

use AppBundle\Entity\Task;
use AppBundle\Form\TaskType;
use Sensio\Bundle\FrameworkExtraBundle\Configuration\Route;
use Symfony\Bundle\FrameworkBundle\Controller\Controller;
use Symfony\Component\HttpFoundation\Request;

class TaskController extends Controller
{
    /**
     * @param Request $request
     * @Route("/", name="index")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function index(Request $request)
    {
       $repo = $this->getDoctrine()->getRepository(Task::class);
       $openTasks = array();
       $inProgressTasks = array();
       $finishedTasks = array();
       $tasks = $repo->findAll();
       foreach ($tasks as $task){
           if($task->getStatus() == "Open"){
               array_push($openTasks, $task);
           }else if($task->getStatus() == "In Progress"){
               array_push($inProgressTasks, $task);
           }else if($task->getStatus() == "Finished"){
               array_push($finishedTasks, $task);
           }
       }

       return $this->render(
           ":task:index.html.twig",
           ["openTasks" => $openTasks ,
            "inProgressTasks" => $inProgressTasks ,
            "finishedTasks" => $finishedTasks]
       );
    }

    /**
     * @param Request $request
     * @Route("/create", name="create")
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function create(Request $request)
    {
        $task = new Task();
        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);
        $errorMsg = "";
        if ($form->isSubmitted()) {
            if ($form->isValid()) {
                $em = $this->getDoctrine()->getManager();
                $em->persist($task);
                $em->flush();
                return $this->redirect("/");
            } else
                $errorMsg = "Invalid form data";
        }
        return $this->render(
            ":task:create.html.twig",
            ["film" => $task, "form" => $form->createView(),
                "errorMsg" => $errorMsg]
        );
    }

    /**
     * @Route("/edit/{id}", name="edit")
     *
     * @param $id
     * @param Request $request
     * @return \Symfony\Component\HttpFoundation\Response
     */
    public function edit($id, Request $request)
    {
        $repo = $this->getDoctrine()->getRepository(Task::class);
        $task = $repo->find($id);
        if ($task == null) {
            return $this->redirect("/");
        }

        $form = $this->createForm(TaskType::class, $task);
        $form->handleRequest($request);
        $errorMsg = "";
        if ($form->isSubmitted()) {
            if ($form->isValid()) {
                $em = $this->getDoctrine()->getManager();
                $em->merge($task);
                $em->flush();
                return $this->redirect("/");
            } else
                $errorMsg = "Invalid form data";
        }
        return $this->render(
            ":task:edit.html.twig",
            ["task" => $task, "form" => $form->createView(),
                "errorMsg" => $errorMsg]
        );
    }
}

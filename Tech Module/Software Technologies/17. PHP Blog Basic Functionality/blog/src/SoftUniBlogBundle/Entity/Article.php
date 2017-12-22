<?php

namespace SoftUniBlogBundle\Entity;

use Doctrine\ORM\Mapping as ORM;

/**
 * Article
 *
 * @ORM\Table(name="articles")
 * @ORM\Entity(repositoryClass="SoftUniBlogBundle\Repository\ArticleRepository")
 */
class Article
{
    public function __construct()
    {
        $this->dateAdded = new \DateTime('now');
    }

    /**
     * @var int
     *
     * @ORM\Column(name="id", type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;

    /**
     * @var string
     *
     * @ORM\Column(name="title", type="string", length=255)
     */
    private $title;

    /**
     * @var string
     *
     * @ORM\Column(name="content", type="text")
     */
    private $content;

     /**
     * @var \DateTime
     *
     * @ORM\Column(name="dateAdded", type="datetime")
     */
    private $dateAdded;

    /**
     * @var string
     */
    private $summary;

    /**
     * @param string
     */
    private function setSummary(){
        $this->summary = substr($this->getContent(), 0, strlen($this->getContent())/2) . "...";
    }

    /**
     * @return string
     */
    public function getSummary(){
        if($this->summary === null){
            $this->setSummary();
        }
        return $this->summary;
    }

    /**
     * @var int
     *
     * @ORM\Column(name="authorId", type="integer")
     */
    private $authorId;

    /**
     * @var string
     *
     * @ORM\Column(name="authorName", type="string", length=255)
     */
    private $authorName;

    /**
     * $var User
     *
     * $ORM\ManyToOne(targetEntity = "SoftUniBlogBundle\Entity\User", inversedBy="users")
     * @ORM\JoinColumn(name="authorId", referencedColumnName="id")
     */
    private $author;

    /**
    /**
     * @param \SoftUniBlogBundle\Entity\User $author
     *
     * @return Article
     */
    public function setAuthor(User $author = null){
        $this->author = $author;
        $this->authorName = $author->getFullName();
        $this->authorId = $this->author->getId();
        return $this;
    }

    /**
     * @return \SoftUniBlogBundle\Entity\User
     */
    public function getAuthor(){
        return $this->author;
    }

    /**
     * @return string
     */
    public function getAuthorName(){
        return $this->authorName;
    }

    /**
     * @param integer $authorId
     *
     * @return Article
     */
    public function setAuthorId($authorId){
        $this->authorId = $authorId;

        return $this;
    }

    /**
     * @return int
     */
    public function getAuthorId(){
        return $this->authorId;
    }

    /**
     * Get id
     *
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * Set title
     *
     * @param string $title
     *
     * @return Article
     */
    public function setTitle($title)
    {
        $this->title = $title;

        return $this;
    }

    /**
     * Get title
     *
     * @return string
     */
    public function getTitle()
    {
        return $this->title;
    }

    /**
     * Set content
     *
     * @param string $content
     *
     * @return Article
     */
    public function setContent($content)
    {
        $this->content = $content;

        return $this;
    }

    /**
     * Get content
     *
     * @return string
     */
    public function getContent()
    {
        return $this->content;
    }

    /**
     * Set dateAdded
     *
     * @param \DateTime $dateAdded
     *
     * @return Article
     */
    public function setDateAdded($dateAdded)
    {
        $this->dateAdded = $dateAdded;

        return $this;
    }

    /**
     * Get dateAdded
     *
     * @return \DateTime
     */
    public function getDateAdded()
    {
        return $this->dateAdded;
    }
}


<?php

namespace AppBundle\Entity;

use Doctrine\ORM\Mapping as ORM;
use Symfony\Component\Validator\Constraints\NotBlank;

/**
 * Anime
 *
 * @ORM\Table(name="animes")
 * @ORM\Entity(repositoryClass="AppBundle\Repository\AnimeRepository")
 */
class Anime
{
    /**
     * @var int
     *
     * @ORM\Column(name="id", type="integer")
     * @ORM\Id
     * @ORM\GeneratedValue(strategy="AUTO")
     */
    private $id;

    /**
     * @var int
     *
     * @ORM\Column(type="integer")
     * @NotBlank
     */
    private $rating;

    /**
     * @var string
     *
     * @ORM\Column(type="string", length=255)
     * @NotBlank
     */
    private $name;

    /**
     * @var string
     *
     * @ORM\Column(type="string", length=255)
     * @NotBlank
     */
    private $description;

    /**
     * @var string
     *
     * @ORM\Column(type="string", length=255)
     * @NotBlank
     */
    private $watched;

    /**
     * @return int
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param int $id
     */
    public function setId( $id)
    {
        $this->id = $id;
    }

    /**
     * @return int
     */
    public function getRating()
    {
        return $this->rating;
    }

    /**
     * @param int $rating
     */
    public function setRating( $rating)
    {
        $this->rating = $rating;
    }

    /**
     * @return string
     */
    public function getName()
    {
        return $this->name;
    }

    /**
     * @param string $name
     */
    public function setName( $name)
    {
        $this->name = $name;
    }

    /**
     * @return string
     */
    public function getDescription()
    {
        return $this->description;
    }

    /**
     * @param string $description
     */
    public function setDescription( $description)
    {
        $this->description = $description;
    }

    /**
     * @return string
     */
    public function getWatched()
    {
        return $this->watched;
    }

    /**
     * @param string $watched
     */
    public function setWatched( $watched)
    {
        $this->watched = $watched;
    }

}


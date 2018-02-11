package animelist.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import animelist.entity.Anime;

public interface AnimeRepository extends JpaRepository<Anime, Integer> {
}

package softuniBlog.config;

import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.AuthorityUtils;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.util.StringUtils;
import softuniBlog.entity.User;

import java.util.ArrayList;
import java.util.Collection;

public class BlogUserDetails extends User implements UserDetails {

    private ArrayList<String> roles;

    private User user;

    public BlogUserDetails(User user, ArrayList<String> roles){
        super(user.getEmail(), user.getFullName(), user.getPassword());

        this.roles = roles;
        this.user = user;
    }

    public User getUSer(){
        return this.user;
    }

    @Override
    public String getUsername(){
        return  this.user.getEmail();
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities(){
        String userRoles = StringUtils.collectionToCommaDelimitedString(this.roles);
        return AuthorityUtils.commaSeparatedStringToAuthorityList(userRoles);
    }

    @Override
    public boolean isAccountNonExpired() {
        return false;
    }

    @Override
    public boolean isAccountNonLocked() {
        return false;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return false;
    }

    @Override
    public boolean isEnabled() {
        return false;
    }
}
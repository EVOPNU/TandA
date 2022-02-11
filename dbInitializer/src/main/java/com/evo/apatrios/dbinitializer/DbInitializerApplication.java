package com.evo.apatrios.dbinitializer;

import com.evo.apatrios.dbinitializer.models.Account;
import com.evo.apatrios.dbinitializer.models.AccountRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class DbInitializerApplication {

    public static void main(String[] args) {
        SpringApplication.run(DbInitializerApplication.class, args);
    }

    @Bean
    CommandLineRunner run(AccountRepository repository){
        return args -> {
            Account admin = new Account();
            admin.setEmail("admin@mail.ru");
            admin.setMoney(0);
            admin.setRole("Admin");
            admin.setPassword("21232f297a57a5a743894a0e4a801fc3");
            repository.save(admin);
        };
    }
}

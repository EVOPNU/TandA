package suraifokkusu.controllers;

import org.springframework.web.bind.annotation.*;
import suraifokkusu.entities.Product;
import suraifokkusu.services.ProductService;

import java.util.List;

@RestController
@RequestMapping("/products")
public class ProductController {
    private final ProductService service;

    public ProductController(ProductService service){
        this.service = service;
    }
    @GetMapping
    public List<Product> findAll(){
        return service.findAll();
    }

    @GetMapping(value = "/{id}")
    public Product findById(@PathVariable Long id){
      return service.findById(id);
  }

    @PostMapping
    public Product save(@RequestBody Product product){
        return service.save(product);
    }

    @PutMapping
    public Product update(@RequestBody Product product){
        return service.save(product);
    }

    @DeleteMapping("/{id}")
    public void delete(@PathVariable Long id){
        service.deleteById(id);
    }
}

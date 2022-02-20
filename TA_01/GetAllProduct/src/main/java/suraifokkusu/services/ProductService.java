package suraifokkusu.services;

import org.springframework.stereotype.Service;
import suraifokkusu.entities.Product;
import suraifokkusu.repositories.ProductRepository;

import javax.transaction.Transactional;
import java.util.List;

@Service
public class ProductService {
    private final ProductRepository productRepository;

    public ProductService(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @Transactional
    public List<Product> findAll() {
        return productRepository.findAll();
    }

    @Transactional
    public Product findById(long id) {
        return productRepository.findById(id).orElseThrow(RuntimeException::new);
    }

    @Transactional
    public Product save(Product product) {
        return productRepository.save(product);
    }

    @Transactional
    public void deleteById(long id) {
        productRepository.deleteById(id);
    }
}

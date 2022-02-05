// Zachet.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//Матрица с четным числом строк и столбцов, поменять местами 1й и 4й квадранты а так же 2й и 3й
//Прямоугольная столбцы по полам делю, слева первый квадрант, справа второй.Потом делю строки 12 - 34

#include <iostream>

int main()
{
    int const n = 4, m = 8; //n-строк и m-столбцов
    int arr[n][m], i, j, r[m];
    std::cout << "Enter matrix elements row by row: " << std::endl;

    for (i = 0; i < n; i++) {

        for (j = 0; j < m; j++) {

            std::cin >> arr[i][j];
        }


    }
    std::cout << "debug" << std::endl;
    for (i = 0; i < n; i++) {

        for (j = 0; j < m; j++) {

            std::cout << arr[i][j] << " ";
        }
        std::cout << std::endl;
    }



    ////1й и
    //std::cout << "1 kvart "  << std::endl;
    //for (i = 0; i < n/2; i++) {

    //    for (j = 0; j < m/2; j++) {

    //        std::cout << arr[i][j];
    //    }
    //    std::cout << std::endl;

    //}
   

 
    ////2й
    //std::cout << "2 kvart " << std::endl;
    //for (i = 0; i < n/2; i++) {

    //    for (j = m/2; j < m; j++) {

    //        std::cout << arr[i][j];
    //    }
    //    std::cout << std::endl;

    //}
    ////3й
    //std::cout << "3 kvart " << std::endl;
    //for (i = n / 2; i < n; i++) {

    //    for (j = 0; j < m / 2; j++) {

    //        std::cout << arr[i][j];
    //    }
    //    std::cout << std::endl;
    //}

    ////4й
    //std::cout << "4 kvart " << std::endl;
    //for (i = n/2; i < n ; i++) {

    //    for (j = m / 2; j < m; j++) {

    //        std::cout << arr[i][j];
    //    }
    //    std::cout << std::endl;

    //}

    //замена

    //1й и 4 
    int temp =  0 ;

    std::cout << "1 и 4 kvart " << std::endl;
    for (i = 0; i < n / 2; i++) {

        for (j = 0; j < m / 2; j++) {
            temp = arr[i][j];
            arr[i][j] = arr[i + n / 2][j + m / 2];
            arr[i + n / 2][j + m / 2] = temp;

        }


    }
   /* for (i = n / 2; i < n; i++) {

        for (j = m / 2; j < m; j++) {
            arr[i][j] = temp[i - n / 2][j - m / 2];
        }


    }*/
    ////debug
    //std::cout << "debug 1 and 4" << std::endl;
    //for (i = 0; i < n; i++) {

    //    for (j = 0; j < m; j++) {

    //        std::cout << arr[i][j];
    //    }
    //    std::cout << std::endl;
    //}


    //2 and 3
    //std::cout << "2 kvart " << std::endl;
    for (i = 0; i < n / 2; i++) {

        for (j = m / 2; j < m; j++) {
            temp = arr[i][j];
            arr[i][j] = arr[i + n / 2][j - m / 2];
            arr[i + n / 2][j - m / 2] = temp;
        }


    }

   /* for (i = n / 2; i < n; i++) {

        for (j = 0; j < m / 2; j++) {

            arr[i][j] = temp[i - n / 2][j + m / 2];
        }

    }*/

    //debug
    std::cout << "result" << std::endl;
    for (i = 0; i < n; i++) {

        for (j = 0; j < m; j++) {

            std::cout << arr[i][j] << " ";
        }
        std::cout << std::endl;
    }
    
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.

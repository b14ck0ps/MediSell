# Medisell

Medisell is an online platform that enables the customers to buy medicines from the comfort of their homes. The platform
consists of a web application built using .NET Framework 4.8.1 with Web API and follows a 3-tier architecture. The
application uses Entity Framework 6 Code First to communicate with a MSSQL database.

## User Roles

Medisell supports the following four user roles:

1. Customer
2. Admin
3. Finance
4. Delivery man

Each role has its specific privileges and functions, and their access is limited according to their roles.

## Features

The application offers the following features:

1. A user-friendly interface for customers to browse and purchase medicine.
2. The ability to track the status of the order.
3. Admin panel for managing medicine, orders, customers, and delivery man.
4. Finance panel for managing transactions and generating reports.
5. Delivery man panel for tracking and updating the status of deliveries.
6. Authentication and authorization for all user roles.
7. Ability to add and remove medicine.
8. Ability to update the medicine's quantity and price.
9. Ability to view the list of customers and their details.
10. Ability to assign delivery man to an order.

## Setup

To run the application, follow these steps:

1. Clone the project.
2. Open the solution file in Visual Studio.
3. Change the database connection string in the web.config file to connect to your MSSQL database.
4. Run the following commands in the Package Manager Console to create the database:
    ```
   update-database -verbose
   ```
5. Build and run the application.

## Conclusion

Medisell provides a convenient way for customers to purchase medicine online, and it offers useful features for admins,
finance, and delivery man to manage their tasks efficiently.

## Contributors

This project is a semester final project developed by four contributors.

1. [AJRAN HOSSAIN](https://github.com/b14ck0ps)
2. [BIBI MARIOM](https://github.com/MariomEmu)
3. [MD. ABDUL HADI CHOWDHURY](https://github.com/hadiChowdhury)
4. [RIFAT TASNIA ISLAM](https://github.com/RifatTasnia)


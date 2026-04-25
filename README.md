# InMemory Database Engine

## Advanced Data Management System in C-Sharp

This project is a high-performance In-Memory Data Engine developed with a focus on software architecture, clean code principles, and advanced design patterns.

# Architecture and Design Patterns

The system implements 8 core design patterns:

## Creational Patterns

* **Singleton:** The Database class is a Singleton.
* **Builder:** Tables are defined through a step-by-step process.
* **Prototype:** Used for the Table Cloning feature.

## Structural Patterns

* **Facade:** Provides a simplified DBClient interface.
* **Composite:** Powering the Query System for AND/OR conditions.

## Behavioral Patterns

* **Command:** Every operation is encapsulated as an object.
* **Observer:** Used for the Logging System.
* **Iterator:** Provides strategies for traversing table rows.

# Key Features

* **Fluent Table Definition:** Clean syntax for schemas.
* **Dynamic Schema Validation:** Strict type enforcement.
* **Complex Logical Queries:** Support for nested search conditions.

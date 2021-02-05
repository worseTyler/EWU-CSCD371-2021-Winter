# EWU-CSCD371-2021-Winter

## See [Docs](Docs)

## Assignment 5

The purpose of this assignment is to write a class library is to learn how to write a generic class and a generic method. To accomplish this you will write a linked list that circles back on itself.

## Reading

Catch Up On Reading (Chapter 1-15 except Chapter 14). This is your chance to get caught up - use it!

## Instructions

- Create a *class library* project called "GenericsHomework.". ❌✔
- Create a node class that can contain a value of any type and points to the next node and traversing the next node points back to the first item.
  - Define the `Node` class
  - Include a constuctor that takes a value.  (No validation is necessary on the value). ❌✔
  - Add a `ToString()` override that writes out the value's `ToString()` result. ❌✔
  - Add a `Next` property that references the next node or else refers back to itself if there are no other nodes in the list. ❌✔
    - The `Next` property should be non-nullable (careful to follow the non-nullable property guidelines) ❌✔
    - The `Next` property setter should be private. ❌✔
    - In addition to non-null validation, the body of the `Next` property should insert the next `Node` (the `value`) into the list. ❌✔
  - Add an `Insert` method that takes a value and inserts a new `Node` instance after the current node (by invoking the `Next` property). ❌✔
  - Add a clear method that effectively removes all items from a list except the current node. Pay attention as to whether you should be
  concerned with the following:
    - Whether it is sufficient to only set Next to itself ❌✔
    - Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔
    - Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage colleciton because all the items point to each other and therefore may never be garbage collected. ❌✔
- You should not rely on any BCL generic classes for your implementation. ❌✔

## Extra Credit

Do one of the following two options (or both if you want extra extra credit) :)

1. Implement a `VennDiagram` structure that contains `n` `Circle`s that only contains homogenous **reference types** of any type. ❌✔

- Each circle contains n items and each item can belong to one more more `Circle` instances.
- You are not required to use a `Node` from earlier in the homework for your venn diagram implementation.
- You are welcome to use exising BCL generic classes for the extra credit.

2. Implement `Systm.Collections.Generic.ICollection<T>` on the `Node` class ❌✔

## Fundamentals

- Ensure you enable nullable reference types, net5 targetted, C# 9.0, warnings as errors, and enabled .NET analyzers for both projects ❌✔
  - For this assignment, always use `Assert.AreEquals<T>()` (the generic version)
- All of the above should be unit tested ❌✔

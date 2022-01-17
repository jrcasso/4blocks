# 4blocks

4blocks, built in Unity3D, is similar to Tetris, but the blocks come from all four directions towards a central pillar.

![](https://imgur.com/p1b2MHZ.png)


# Controls

To control a moving block, click it. Then use either the arrow keys or WASD keys to move the object. Move the block in the direction opposite of the direction of travel to rotate the block.

# Deployment

4blocks can be easily installed in Kubernetes via its Helm chart. From the project root:

```sh
helm install 4blocks helm/
```

and that's it. This will run a container image `jrcasso/4blocks` which contains the latest build of this application project. Optional terraform configuration is provided if one wishes to place an exposed load balancer on a custom domain according to my [organizational networking specification](https://github.com/jrcasso/mean-demo/issues/50#issuecomment-706654629). A devcontainer configuration is provided to facilitate Terraform deployment.

---
# Development Setup

Ensure you have the following prerequisites satisfied:
 - Unity3D
 - Visual Studio
 - (Optional) Docker for Desktop
 - (Optional) VS Code
 - (Optional) VS Code Extensions: Remote Containers
   - Download and install Microsoft's VS Code extension for developing in [Remote Containers](vscode:extension/ms-vscode-remote.remote-containers)

>Note: This is partially a VS Code Remote Containers development project; infrastructure development is done within a container to reduce initial time-to-develop. Getting the infrastructure of this project up and running can be as simple as pulling down the repository, running the Docker daemon the host machine, opening the project in VS Code, and clicking twice.

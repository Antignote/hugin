# Kubernetes

## Aspire

Aspire is able to generate [k8s manifest](https://aspire.dev/integrations/compute/kubernetes/).

Generate k8s manifest with aspire:

```bash
aspire publish -o k8s-artifacts
```

## Local

Use [Kind](https://kind.sigs.k8s.io/) for local development.

Ensure a cluster is created:

```bash
# view clusters
kind get clusters
# create cluster if needed
kind create cluster --name <cluster name>
# delete cluster
kind delete cluster --name <cluster name>
```

## Dashboard

The original docs can be found at [kubernetes.io](https://kubernetes.io/docs/tasks/access-application-cluster/web-ui-dashboard/).

Deploy the dashboard UI:

```bash
# Add kubernetes-dashboard repository
helm repo add kubernetes-dashboard https://kubernetes.github.io/dashboard/
# Deploy a Helm Release named "kubernetes-dashboard" using the kubernetes-dashboard chart
helm upgrade --install kubernetes-dashboard kubernetes-dashboard/kubernetes-dashboard --create-namespace --namespace kubernetes-dashboard
```

Portforward the dashboard from the cluster:

```bash
kubectl -n kubernetes-dashboard port-forward svc/kubernetes-dashboard-kong-proxy 8443:443
# dashboard available at https://localhost:8443 (requires token, see below)
```

Generate a token by applying the service account to the cluster:

```bash
# Run from the project root
kubectl apply -f charts/service-account.yaml
```

Then generate a token via:

```bash
k -n kube-system create token admin-user
```

### Cleanup

```bash
# remove dashboard
kubectl delete namespace kubernetes-dashboard

# remove service account
kubectl delete -f charts/service-account.yaml
```

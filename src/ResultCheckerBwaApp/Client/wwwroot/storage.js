window.localStorageSetItem = (key, value) => {
    localStorage.setItem(key, value);
};

window.localStorageGetItem = (key) => {
    return localStorage.getItem(key);
};

window.localStorageClear = () => {
    localStorage.clear();
};

window.sessionStorageSetItem = (key, value) => {
    sessionStorage.setItem(key, value);
};

window.sessionStorageGetItem = (key) => {
    return sessionStorage.getItem(key);
};

window.sessionStorageClear = () => {
    sessionStorage.clear();
};
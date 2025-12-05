import tomllib


class Settings:
    config_file_url = 'app_config.toml'

    # Атрибуты, которые будут инициализированы
    is_debug: bool
    hosts: list[str]
    port: int
    host: str  # Вычисленный хост

    def __init__(self):
        self.read_config_file()

    def read_config_file(self):
        with open(self.config_file_url, 'rb') as f:  # Открываем в бинарном режиме для tomllib
            data = tomllib.load(f)  # Разбираем TOML

        self.is_debug = data.get('is_debug', False)  # Получаем значение или дефолт
        self.hosts = data.get('hosts', ["127.0.0.1"])
        self.port = data.get('port', 8000)


        if self.hosts:
            self.host = self.hosts[int(self.is_debug)]
        else:
            # Если список hosts пуст, используем дефолт
            self.host = "127.0.0.1" if self.is_debug else "0.0.0.0"

    def get_settings(self):
        return (self.host, self.port)


settings = Settings()
host, port = settings.get_settings()

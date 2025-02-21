using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedisDemo
{

    public class RedisLockManager
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly string _lockKey;
        private readonly TimeSpan _lockTimeout;
        private readonly TimeSpan _lockRenewalTimeout;

        public RedisLockManager(string redisConnectionString, string lockKey, TimeSpan lockTimeout, TimeSpan lockRenewalTimeout)
        {
            _redis = ConnectionMultiplexer.Connect(redisConnectionString);
            _lockKey = lockKey;
            _lockTimeout = lockTimeout;
            _lockRenewalTimeout = lockRenewalTimeout;
        }

        public async Task<bool> AcquireLockAsync(string lockValue, CancellationToken cancellationToken = default)
        {
            var database = _redis.GetDatabase();
            var endTime = DateTimeOffset.Now.Add(_lockTimeout);
            while (DateTimeOffset.Now < endTime)
            {
                if (await database.LockTakeAsync(_lockKey, lockValue, _lockTimeout))
                {
                    // 成功获取锁，启动一个后台任务来续期锁（防止死锁）
                    _ = Task.Run(async () => await RenewLockAsync(database, _lockKey, lockValue, cancellationToken), cancellationToken);
                    return true;
                }
                await Task.Delay(100, cancellationToken); // 等待一小段时间后重试
            }
            return false; // 超时未获取到锁
        }

        private async Task RenewLockAsync(IDatabase database, string lockKey, string lockValue, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(_lockRenewalTimeout, cancellationToken); // 等待续期时间后尝试续期锁
                if (await database.LockExtendAsync(lockKey, lockValue, TimeSpan.FromSeconds(10))) // 尝试续期10秒，根据需要调整时间长度和频率
                {
                    // 续期成功，继续等待下一个续期时间点
                }
                else if (await database.LockReleaseAsync(lockKey, lockValue)) // 如果续期失败，尝试释放锁（以防万一）
                {
                    break; // 释放锁后退出循环，避免无限循环尝试续期一个已经不再持有的锁
                }
            }
        }

        public async Task ReleaseLockAsync(string lockValue)
        {
            var database = _redis.GetDatabase();
            await database.LockReleaseAsync(_lockKey, lockValue); // 释放锁
        }
    }
}
